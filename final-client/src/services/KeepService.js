import { AppState } from '../AppState'
import { accountService } from './AccountService'
import { api } from './AxiosService'
import { profileService } from './ProfileService'

class KeepService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeepById(id) {
    const res = await api.get('api/keeps/' + id)
    console.log(res)
    AppState.activeKeep = res.data
  }

  async createKeep(keep, userId) {
    const res = await api.post('api/keeps', keep)
    console.log(res)
    AppState.vaults = [res.data]
    await profileService.getKeepsByProfile(userId)
    await accountService.getKeepsByAccount()
  }

  async deleteKeep(id) {
    const res = await api.delete('api/keeps/' + id)
    console.log(res)
    const foundKeep = AppState.keeps.findIndex(k => k.id === id)
    AppState.keeps.splice(foundKeep, 1)
    const profileKeep = AppState.profileKeeps.findIndex(pk => pk.id === id)
    AppState.profileKeeps.splice(profileKeep, 1)
    await accountService.getKeepsByAccount()
  }
}

export const keepService = new KeepService()
