<template>
  <div class="row mt-3">
    <div class="col-12 text-center">
      <h1 class="shadow rounded">Welcome to some dark web warehouses</h1>
    </div>
  </div>
  <!-- NOTE warehouses go here -->
  <div class="row">
    <Warehouse v-for="w in warehouses" :key="w.id" :warehouse="w" />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  name: 'Home',
  setup() {
    return {
      warehouses: computed(() => AppState.warehouses)
    }
  }
}
</script>

<style scoped lang="scss">
</style>
