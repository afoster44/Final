<template>
  <div class="profile-page container-fluid">
    <div class="row">
      <div class="col-2 mt-2">
        <img :src="state.profile.picture" alt="">
      </div>
      <div class="col-8 mt-2">
        <h1>{{ state.profile.name }}</h1>
        <p>Vaults: {{ state.profileVaults.length }}</p>
        <p>Keeps: {{ state.profileKeeps.length }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-1">
        <h1>Vaults: </h1>
      </div>
      <div class="col-9 ml-4">
        <p><CreateVaultModal /></p>
      </div>
    </div>
    <div class="row">
      <VaultComponent v-for="vault in state.profileVaults" :key="vault.id" :vault="vault" />
    </div>
    <div class="row">
      <div class="col-1 mr-4">
        <h1>Keeps:</h1>
      </div>
      <div class="col-9">
        <CreateKeepModal />
      </div>
    </div>
    <div class="card-columns">
      <KeepComponent v-for="keep in state.profileKeeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { onMounted, computed } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { AppState } from '../AppState'

export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.profile),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults)
    })
    onMounted(() => {
      profileService.getProfile(route.params.id)
      profileService.getVaultsByProfile(route.params.id)
      profileService.getKeepsByProfile(route.params.id)
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.card-columns {
  @media(max-width: 767px) {
    column-count: 2;
  }
  @media(min-width: 768px) {
    column-count: 3;
  }
  @media(min-width: 1200px) {
    column-count: 4;
  }
}

</style>
