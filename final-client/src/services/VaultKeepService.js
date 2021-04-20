import { api } from './AxiosService'
import { vaultService } from './VaultService'

class VaultKeepService {
  async addKeepToVault(vaultKeep) {
    const res = await api.post('api/vaultkeeps', vaultKeep)
    console.log(res)
  }

  async removeKeepFromVault(vaultKeepId, vaultId) {
    const res = await api.delete('api/vaultkeeps/' + vaultKeepId)
    console.log(res)
    vaultService.getKeepsByVaultId(vaultId)
  }
}

export const vaultKeepService = new VaultKeepService()
