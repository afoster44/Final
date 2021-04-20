<template>
  <div class="VaultKeepDropdownComponent" v-if="vaultKeep">
    <a class="dropdown-item" href="#" @click.prevent="removeKeepFromVault">
      {{ vaultKeep.name }}
    </a>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { useRoute } from 'vue-router'
import { vaultKeepService } from '../services/VaultKeepService'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  name: 'VaultKeepDropdownComponent',
  props: {
    vaultKeep: {
      type: Object,
      required: true
    },
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      async removeKeepFromVault() {
        await vaultKeepService.removeKeepFromVault(props.vaultKeep.vaultKeepId, route.params.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
