import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { Observable } from "rxjs"

@Injectable({
  providedIn: "root",
})
export class SalesDataService {
  constructor(private http: HttpClient) {}

  getOrders = (pageIndex: number, pageSize: number): Observable<any> =>
    this.http.get(
      `https://localhost:5001/api/orders/page/${pageIndex}/${pageSize}`
    )

  getTotalByCustomer = (numberOfCustomers: number): Observable<any> =>
    this.http.get(
      `https://localhost:5001/api/orders/total_by_customer/${numberOfCustomers}`
    )

  getTotalByState = (): Observable<any> =>
    this.http.get("https://localhost:5001/api/orders/total_by_state")
}
