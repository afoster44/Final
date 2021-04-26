<template>
  <div class="vault-component">
    <div class="card bg-dark">
      <div class="card-container">
        <div class="card-title">
          <div v-if="state.account">
            <h3>{{ vault.name }} <span><i class="fa fa-trash d-flex align-content-end" aria-hidden="true" @click="deleteVault" v-if="state.account.id === vault.creatorId"></i></span> </h3>
          </div>
        </div>
        <router-link :to="{name: 'VaultPage', params: {id: vault.id}}">
          <div class="card-text text-danger">
            {{ vault.description }}
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'

export default {
  name: 'VaultComponent',
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      route,
      deleteVault() {
        const res = window.confirm('Are you sure you want to delete this?')
        if (res) {
          vaultService.deleteVault(props.vault.id, route.params.id)
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
