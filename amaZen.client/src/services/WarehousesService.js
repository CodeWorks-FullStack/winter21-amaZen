import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class WarehousesService {
  async getAll() {
    const res = await api.get('api/warehouses')
    AppState.warehouses = res.data
  }

  async getProductsByWarehouse(warehouseId) {
    const res = await api.get(`api/warehouses/${warehouseId}/products`)
    AppState.activeWarehouseProducts = res.data
  }
}

export const warehousesService = new WarehousesService()
