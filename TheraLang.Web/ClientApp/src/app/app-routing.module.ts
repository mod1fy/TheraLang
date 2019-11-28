import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectComponent } from './project/project.component';
import { HomeComponent } from './home/home.component';
import { ProjectInfoComponent } from './project-info/project-info.component';
import { ProjectParticipantsComponent } from './project-participants/project-participants.component';
import {CmsModule} from './cms/cms.module';
import { GeneralResourcesTableComponent } from './general-resources/general-resources-tables/general-resources-table/general-resources-table.component';
import { ErrorComponent } from './shared/components/error/error.component';
import { ResultComponent } from './result/result.component';
import { DonationComponent } from './donation/donation.component';
import { ProjectTypeComponent } from './project-type/project-type.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'participants', component:ProjectParticipantsComponent },
  { path: 'project/:id', component: ProjectInfoComponent },
  { path: 'projects', component: ProjectComponent },
  { path: 'donation/:projectId', component: DonationComponent },
  { path: 'resources', component: GeneralResourcesTableComponent },
  { path: 'result/:donationId', component:ResultComponent },
  { path: 'error', component: ErrorComponent },
  { path: '**', loadChildren: () => CmsModule},
  {path: 'projectTypes', component: ProjectTypeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],

})
export class AppRoutingModule { }

export const routingComponents = [
  ProjectParticipantsComponent, ProjectComponent, HomeComponent, ProjectInfoComponent,
  GeneralResourcesComponent, ErrorComponent, ProjectTypeComponent
  ResultComponent, DonationComponent
];
