import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }
}

export const keepService = new KeepService()
