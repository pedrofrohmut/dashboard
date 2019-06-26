import Order from "./models/Order"

export const MOCK_ORDERS: Order[] = [
  {
    id: 1,
    customer: {
      id: 1,
      name: "Main St Bakery",
      email: "mainst@mail.com",
      state: "CO",
    },
    total: 230,
    placed: new Date(2017, 12, 1),
    fulfilled: new Date(2017, 12, 2),
    status: "completed",
  },
  {
    id: 2,
    customer: {
      id: 1,
      name: "Main St Bakery",
      email: "mainst@mail.com",
      state: "CO",
    },
    total: 230,
    placed: new Date(2017, 12, 1),
    fulfilled: new Date(2017, 12, 2),
    status: "completed",
  },
  {
    id: 3,
    customer: {
      id: 1,
      name: "Main St Bakery",
      email: "mainst@mail.com",
      state: "CO",
    },
    total: 230,
    placed: new Date(2017, 12, 1),
    fulfilled: new Date(2017, 12, 2),
    status: "completed",
  },
  {
    id: 4,
    customer: {
      id: 1,
      name: "Main St Bakery",
      email: "mainst@mail.com",
      state: "CO",
    },
    total: 230,
    placed: new Date(2017, 12, 1),
    fulfilled: new Date(2017, 12, 2),
    status: "completed",
  },
  {
    id: 5,
    customer: {
      id: 1,
      name: "Main St Bakery",
      email: "mainst@mail.com",
      state: "CO",
    },
    total: 230,
    placed: new Date(2017, 12, 1),
    fulfilled: new Date(2017, 12, 2),
    status: "completed",
  },
]
