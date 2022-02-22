CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS products(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  price decimal NOT NULL,
  sku VARCHAR(255) NOT NULL,
  description VARCHAR(255)
) default charset utf8 COMMENT '';

INSERT INTO products(name, price, sku, description)
VALUES("MeeMas ping pong paddle", .99, "no idea", "30 year old ping pong paddle called nancy");
INSERT INTO products(name, price, sku, description)
VALUES("Purple Fuzzy Dice", 50, "dicepurlple222", "If you wanna look cool buy these");
INSERT INTO products(name, price, sku, description)
VALUES("Dr Disrespect Memoir", 10000, "Lambo", "AT THE TIPPITY TOP OF THE MOUNTAIN");
INSERT INTO products(name, price, sku, description)
VALUES("Subaru", 15000, "forrester", "Blown head gasket, turbo noises, north end lifestyle");

CREATE TABLE IF NOT EXISTS warehouses(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  location VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';

INSERT INTO warehouses(location)
VALUES("Mordor");
INSERT INTO warehouses(location)
VALUES("Provo");
INSERT INTO warehouses(location)
VALUES("Narnia");
INSERT INTO warehouses(location)
VALUES("Atlantis");
INSERT INTO warehouses(location)
VALUES("Zeta Halo");
INSERT INTO warehouses(location)
VALUES("Garden of Eden");

CREATE TABLE IF NOT EXISTS warehouse_products(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  productId INT NOT NULL,
  warehouseId INT NOT NULL,

  FOREIGN KEY(productId) REFERENCES products(id) ON DELETE CASCADE,
  FOREIGN KEY(warehouseId) REFERENCES warehouses(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO warehouse_products(productId, warehouseId)
VALUES(2, 1);
INSERT INTO warehouse_products(productId, warehouseId)
VALUES(1, 6);

SELECT * FROM warehouse_products;
SELECT * FROM products;
SELECT * FROM warehouses;


SELECT
p.*,
w.location,
wp.id AS warehouseProductId,
wp.productId AS productId,
wp.warehouseId AS warehouseId
FROM warehouse_products wp
JOIN warehouses w ON w.id = wp.warehouseId
JOIN products p on p.id = wp.productId
WHERE wp.warehouseId = 1;

