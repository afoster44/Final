import Axios from 'axios'

export const baseURL = window.location.origin.includes('localhost') ? 'https://localhost:5001' : ''
export const api = Axios.create({
  baseURL,
  timeout: 8000
})

export const setBearer = (bearer) => {
  api.defaults.headers.authorization = bearer
}

export const resetBearer = () => {
  api.defaults.headers.authorization = ''
}
