import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from './ProfileService'

class VaultService {
  async getVaults() {
    const res = await api.get('api/vaults/')
    AppState.vaults = res.data
  }

  async createVault(vault, userId) {
    const res = await api.post('api/vaults', vault)
    console.log(res)
    // AppState.profileVaults = [...AppState.profileVaults, res.data]

    // AppState.vaults = [res.data]
    await profileService.getVaultsByProfile(userId)
  }

  async deleteVault(vaultId, userId) {
    await api.delete('api/vaults/' + vaultId)
    // const res = await api.get('api/profiles/' + userId + '/vaults')
    await profileService.getVaultsByProfile(userId)
  }
}

export const vaultService = new VaultService()
