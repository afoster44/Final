import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from './ProfileService'

class KeepService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async createKeep(keep, userId) {
    const res = await api.post('api/keeps', keep)
    console.log(res)
    AppState.vaults = [res.data]
    await profileService.getKeepsByProfile(userId)
  }

  async editKeep(keep) {

  }
}

export const keepService = new KeepService()
