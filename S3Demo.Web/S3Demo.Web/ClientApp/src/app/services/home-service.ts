import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class HomeService {
  constructor(private http: HttpClient) {

  }
  getReadingData(buildingId, objectId, dataFieldId) {
    return this.http.get(environment.apiEndPoint +
      "home/" +
      buildingId +
      "/" +
      objectId +
      "/" +
      dataFieldId);
  }
}
