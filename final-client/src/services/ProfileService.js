import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfileService {
  async getProfile(id) {
    const res = await api.get('api/profiles/' + id)
    console.log(res)
    AppState.profile = res.data
  }

  async getKeepsByProfile(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    console.log(res)
    AppState.profileKeeps = res.data
  }

  async getVaultsByProfile(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    console.log(res)
    AppState.profileVaults = res.data
  }
}

export const profileService = new ProfileService()
