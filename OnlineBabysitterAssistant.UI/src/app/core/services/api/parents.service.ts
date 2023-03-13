import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivityModel, AddActivityModel } from 'src/app/shared/models/activity-model';
import { ChildModel } from 'src/app/shared/models/chlld-model';
import { BabysitterModel, UserModel } from 'src/app/shared/models/user-model';
import { UserType } from 'src/app/shared/models/user-type';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class ParentsService {

  constructor(private http: HttpClient,
              private authService: AuthenticationService) { }

  getChildren(){
    let currentUser = this.authService.getCurrentUser();
    switch(currentUser.type.toString())
    {
      case UserType[UserType.PARENT]:
        return this.http.get<ChildModel[]>(`${environment.apiUrl}/api/parent/children`);
      case UserType[UserType.BABYSITTER]:
        return this.http.get<ChildModel[]>(`${environment.apiUrl}/api/babysitter/get-my-children`);
    }
    return this.http.get<ChildModel[]>(`${environment.apiUrl}/api/parent/children`);
  }

  addChildActivity(model: AddActivityModel){
    return this.http.post<any>((`${environment.apiUrl}/api/babysitter/add-child-activity`), model);
  }

  getChildActivities(childId: number){
    return this.http.get<ActivityModel[]>(`${environment.apiUrl}/api/babysitter/child-activities/${childId}`);
  }

  getParentBabysitters(){
    return this.http.get<UserModel[]>(`${environment.apiUrl}/api/parent/babysitters`);
  }

  getAllBabysitters(){
    return this.http.get<BabysitterModel[]>(`${environment.apiUrl}/api/parent/all-babysitters`);
  }

  connectBabysitter(id: number){
    return this.http.post<any>(`${environment.apiUrl}/api/parent/connect-babysitter`, id);
  }

  disconnectBabysitter(id: number){
    return this.http.delete<any>(`${environment.apiUrl}/api/parent/disconnect-babysitter`, {body:id});
  }

  asssignBabysitterToChild(childId: number, babysitterId:number){
    let model = {
      childId: childId,
      babysitterId: babysitterId
    }
    return this.http.post<ChildModel>(`${environment.apiUrl}/api/parent/assign-babysitter-to-child`, model);
  }

  unassignBabysitterFromChild(childId: number){
    return this.http.post<ChildModel>(`${environment.apiUrl}/api/parent/unassign-babysitter-from-child`, childId);
  }

  getMyParents(){
    return this.http.get<UserModel[]>(`${environment.apiUrl}/api/babysitter/get-my-parents`)
  }

  addNewChild(child:any){
    return this.http.post(`${environment.apiUrl}/api/parent/add-child`, child)
  }
}
