import { AppState } from '../AppState'
import { accountService } from './AccountService'
import { api } from './AxiosService'
import { profileService } from './ProfileService'

class VaultService {
  async getVaults() {
    const res = await api.get('api/vaults/')
    AppState.vaults = res.data
  }

  async getVaultsById(id) {
    const res = await api.get('api/vaults/' + id)
    console.log(res)
    AppState.activeVault = res.data
  }

  async createVault(vault, userId) {
    const res = await api.post('api/vaults', vault)
    console.log(res)
    // AppState.profileVaults = [...AppState.profileVaults, res.data]

    // AppState.vaults = [res.data]
    await profileService.getVaultsByProfile(userId)
    await accountService.getVaultsByAccount()
  }

  async deleteVault(vaultId, userId) {
    await api.delete('api/vaults/' + vaultId)
    // const res = await api.get('api/profiles/' + userId + '/vaults')
    await profileService.getVaultsByProfile(userId)
    await accountService.getVaultsByAccount()
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    console.log(res)
    AppState.vaultKeeps = res.data
  }
}

export const vaultService = new VaultService()
