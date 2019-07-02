import Customer from "./Customer"

export default interface Order {
  // id: number
  // customer: Customer
  // total: number
  // placed: Date
  // fulfilled: Date
  // status: string
  id: number
  customer: Customer
  total: number
  placed: Date
  completed: number
}
