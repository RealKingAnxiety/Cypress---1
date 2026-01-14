import { faker } from '@faker-js/faker';

export function generateFakeProduct() {
  return {
    name: faker.commerce.productName(),
    price: faker.commerce.price(),
    inventory: faker.number.int({ min: 1, max: 100 })
  };
}
