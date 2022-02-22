<template>
  <div class="col-md-3">
    <h3
      class="selectable"
      :data-bs-target="`#warehouse-modal-${warehouse.id}`"
      warehouse.id
      data-bs-toggle="modal"
      @click="getProductsByWarehouse()"
    >
      {{ warehouse.location }}
    </h3>
  </div>

  <!-- WAREHOUSE MODAL -->
  <Modal :id="`warehouse-modal-${warehouse.id}`">
    <template #modal-header-slot>
      <h1>{{ warehouse.location }}</h1>
    </template>
    <template #modal-body-slot>
      <div v-for="wp in warehouseProducts" :key="wp.id">
        <div class="row">
          <div class="col-12">
            <p>{{ wp.name }}</p>
            <small>${{ wp.price }}</small>
          </div>
        </div>
      </div>
      <div class="mt-5">
        <div class="dropdown">
          <button
            class="btn btn-secondary dropdown-toggle"
            type="button"
            id="dropdownMenuButton1"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Products
          </button>
          <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
            <li
              v-for="p in products"
              :key="p.id"
              class="selectable p-2"
              @click="addToWarehouse(p.id)"
            >
              {{ p.name }}
            </li>
          </ul>
        </div>
      </div>
    </template>
  </Modal>
</template>


<script>
import { computed } from "@vue/reactivity"
import { warehousesService } from "../services/WarehousesService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { AppState } from "../AppState"
import { warehouseProductsService } from "../services/WarehouseProductsService"
export default {
  props: {
    warehouse: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async getProductsByWarehouse() {
        try {
          await warehousesService.getProductsByWarehouse(props.warehouse.id)
        } catch (error) {
          Pop.toast(error.message)
          logger.log(error)
        }
      },
      async addToWarehouse(productId) {
        try {
          const warehouseProduct = { productId: productId, warehouseId: props.warehouse.id }
          await warehouseProductsService.addToWarehouse(warehouseProduct)
          Pop.toast("Product was added!", "success")
        } catch (error) {
          Pop.toast(error.message)
          logger.log(error)
        }
      },
      warehouseProducts: computed(() => AppState.activeWarehouseProducts),
      products: computed(() => AppState.products)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>
