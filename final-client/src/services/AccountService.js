import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getKeepsByAccount() {
    const res = await api.get('/account/keeps')
    console.log('got keeps by account', res)
    AppState.accountKeeps = res.data
  }

  async getVaultsByAccount() {
    const res = await api.get('/account/vaults')
    console.log('got vaults by account id', res)
    AppState.accountVaults = res.data
  }
}

export const accountService = new AccountService()
