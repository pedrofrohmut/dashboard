export default interface Server {
  // data model
  id: number
  name: string
  isOnline: boolean
  // optional
  color?: string
  buttonText?: string
}
