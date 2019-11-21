import {Injectable, OnDestroy} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Project } from './project';
import { baseUrl } from '../shared/api-endpoint.constants';
import { RequestStatus } from '../request-status-enum';

@Injectable()
export class HttpService{
  
    constructor(private http: HttpClient){ }
      
     private url = baseUrl;
     
    getAllProjects(){
        return this.http.get(this.url + 'projects');
    }
  
    getProjectInfo(id: number) {
        return this.http.get(this.url + 'project' + '/' + id);
    }
     
     getPayment(){
        return this.http.get(this.url + 'payment');
    }

     getAllProjectParticipants(){
        return this.http.get(this.url + 'participants');
      }

    changeParticipationStatus (requestId: number, requestStatus: RequestStatus){
        return this.http.put(this.url + 'participants' + '/' + requestId, requestStatus);
    }   
 
    getAllResourcesById(projectId: number) {
        return this.http.get(this.url + 'project' + '/' + projectId + '/' + 'resources');
    }  

    createProject(project:Project) {
        return this.http.post(this.url, project);
    }

    updateProject(project: Project) {
        return this.http.put(this.url + '/' + project.id, project);
    }
  
}
