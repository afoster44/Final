<template>
  <div class="keep-display-modal">
    <!-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
      Launch demo modal
    </button> -->

    <div class="modal fade bd-example-modal-lg"
         id="keepModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="myLargeModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="container-fluid">
            <div class="row d-flex">
              <div class="col-6 mt-2 mb-2">
                <img :src="state.keep.img" alt="">
              </div>
              <div class="col-6">
                <div class="row">
                  <div class="col-8">
                    <span><i class="fa fa-eye mr-1" aria-hidden="true">{{ state.keep.views }}</i></span>
                    <i class="fa fa-external-link ml-2 mr-2" aria-hidden="true"> {{ state.keep.keeps }}</i>
                    <i class="fa fa-share mr-2" aria-hidden="true"> {{ state.keep.shares }}</i>
                  </div>
                  <div class="col-4 d-flex justify-content-end">
                    <span aria-hidden="true" class="mr-1" data-dismiss="modal">&times;</span>
                  </div>
                </div>
                <div class="row text-center mt-3 mb-1">
                  <div class="col-10 offset-1">
                    <h1>
                      {{ state.keep.name }}
                    </h1>
                  </div>
                </div>
                <div class="row text-center mt-5">
                  <div class="col-10 offset-1  border-bottom border-dark">
                    {{ state.keep.description }}
                  </div>
                </div>
                <div class="row bottom">
                  <div class="col-3">
                    <div class="dropdown">
                      <button class="btn btn-secondary dropdown-toggle"
                              type="button"
                              id="dropdownMenuButton"
                              data-toggle="dropdown"
                              aria-haspopup="true"
                              aria-expanded="false"
                      >
                        Vaults here
                      </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <VaultDropdownComponent v-for="vault in state.accountVaults" :key="vault.id" :vault="vault" />
                      </div>
                    </div>
                  </div>
                  <div class="col-1 offset-3 d-flex align-items-center justify-content-center">
                    <i class="fa fa-trash" aria-hidden="true" @click="deleteKeep"></i>
                  </div>
                  <div class="col-3" v-if="state.keep.creator">
                    <i class="fa fa-user" aria-hidden="true"><span class="ml-1">{{ state.keep.creator.name }}</span></i>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'

export default {
  name: 'KeepDisplayModal',
  setup() {
    const state = reactive({
      keep: computed(() => AppState.activeKeep),
      accountVaults: computed(() => AppState.accountVaults)
    })
    onMounted(() => {
    })
    return {
      state,
      async deleteKeep() {
        await keepService.deleteKeep(state.keep.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img {
  width: 100%;
  border-radius: 2%;
}
.bottom {
  position: absolute;
  bottom: 1%;
}
</style>
