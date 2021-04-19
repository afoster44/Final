<template>
  <div class="create-keep-modal">
    <div class="create-vault-modal">
      <i class="fa fa-plus btn btn-primary"
         aria-hidden="true"
         type="button"
         data-toggle="modal"
         data-target="#exampleModal2"
      ></i>

      <!-- Modal -->
      <div class="modal fade"
           id="exampleModal2"
           tabindex="-1"
           role="dialog"
           aria-labelledby="exampleModalLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">
                Want to make a new Keep? :P
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form @submit.prevent="createKeep">
                <div class="form-group">
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Name"
                    name="name"
                    id="name"
                    aria-describedby="helpId"
                    v-model="state.keep.name"
                  />
                </div>
                <div class="form-group">
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Description"
                    name="description"
                    id="description"
                    aria-describedby="helpId"
                    v-model="state.keep.description"
                  >
                </div>
                <div class="form-group">
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Img"
                    name="img"
                    id="img"
                    aria-describedby="helpId"
                    v-model="state.keep.img"
                  >
                </div>
                <button type="submit" class="btn btn-primary">
                  Create Keep
                </button>
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { keepService } from '../services/KeepService'
import { useRoute } from 'vue-router'

export default {
  name: 'CreateKeepModal',
  setup() {
    const route = useRoute()
    const state = reactive({
      keep: {}
    })
    return {
      state,
      async createKeep() {
        await keepService.createKeep(state.keep, route.params.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
