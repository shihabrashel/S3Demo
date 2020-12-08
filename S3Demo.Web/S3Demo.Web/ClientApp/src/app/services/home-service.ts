import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class HomeService {
  constructor(private http: HttpClient) {

  }
  getReadingData(buildingId: number, objectId: number, dataFieldId: number, startDate: string, endDate: string) {
    return this.http.get(environment.apiEndPoint +
      "home/" + buildingId + "/" + objectId +"/" +dataFieldId + "/" + startDate + "/" +endDate);
  }
  getBuildings() {
    return this.http.get(environment.apiEndPoint +
      "home/buildings");
  }
  getObjects() {
    return this.http.get(environment.apiEndPoint +
      "home/objects");
  }
  getDataFields() {
    return this.http.get(environment.apiEndPoint +
      "home/datafields");
  }
}
