import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class WarehouseProductsService {
  async addToWarehouse(warehouseProduct) {
    const res = await api.post("api/warehouseProducts", warehouseProduct)
    logger.log('warehouse products res', res.data)
  }
}

export const warehouseProductsService = new WarehouseProductsService()
