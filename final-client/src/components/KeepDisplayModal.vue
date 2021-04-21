<template>
  <div class="keep-display-modal">
    <!-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
      Launch demo modal
    </button> -->

    <div class="modal fade bd-example-modal-xl"
         id="keepModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="myLargeModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-xl" role="document">
        <div class="modal-content">
          <div class="container-fluid">
            <div class="row d-flex">
              <div class="col-md-6 mt-2 mb-2">
                <img :src="state.keep.img" alt="">
              </div>
              <div class="col-md-6 col-sm-6">
                <div class="row">
                  <div class="col-md-8 col-sm-8">
                    <span><i class="fa fa-eye mr-1" aria-hidden="true">{{ state.keep.views }}</i></span>
                    <i class="fa fa-external-link ml-2 mr-2" aria-hidden="true"> {{ state.keep.keeps }}</i>
                    <i class="fa fa-share mr-2" aria-hidden="true"> {{ state.keep.shares }}</i>
                  </div>
                  <div class="col-md-4 col-sm-4 d-flex justify-content-end">
                    <span aria-hidden="true" class="mr-1" data-dismiss="modal">&times;</span>
                  </div>
                </div>
                <div class="row text-center mt-3 mb-1">
                  <div class="col-md-10 col-sm-10 offset-md-1 offset-sm-1">
                    <h1>
                      {{ state.keep.name }}
                    </h1>
                  </div>
                </div>
                <div class="row text-center mt-1">
                  <div class="col-md-10 col-sm-10 offset-md-1 offset-sm-1  border-bottom border-dark">
                    {{ state.keep.description }}
                  </div>
                </div>
                <div class="row bottom">
                  <div class="col-md-3 col-sm-12">
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
                  <div class="col-md-1 col-sm-12" v-if="state.keep.creatorId === state.account.id">
                    <i class="fa fa-trash" aria-hidden="true" @click="deleteKeep"></i>
                  </div>
                  <div class="col-md-3 col-sm-12" v-if="state.keep.creator">
                    <i class="fa fa-user" aria-hidden="true"><span class="">{{ state.keep.creator.name }}</span></i>
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
      accountVaults: computed(() => AppState.accountVaults),
      account: computed(() => AppState.account)
    })
    onMounted(() => {
    })
    return {
      state,
      async deleteKeep() {
        const res = window.confirm('Are you sure you want to delete this keep?')
        if (res) {
          await keepService.deleteKeep(state.keep.id)
        }
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
    height: 5rem !important;
    align-items: flex-end;
    justify-content: center;
    justify-content: space-evenly;
}
</style>
