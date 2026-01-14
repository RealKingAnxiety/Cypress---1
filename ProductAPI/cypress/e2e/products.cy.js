import { generateFakeProduct } from '../../src/utils/fakeProduct'

describe('Products Page', () => {

  it('displays a list of products', () => {

    cy.visit('http://localhost:5267/index.html')

    cy.contains('h1', 'Products:')

    cy.get('#products-list')

    cy.get('#products-list li')
      .should('have.length.at.least', 2)
  })

  it('creates a new product and verifies it appears in the list', () => {

    cy.visit('http://localhost:5267/index.html')

    cy.contains('button, a', 'Create Product').click()

    cy.get('input[name="name"]').type('Test Product')
    cy.get('input[name="price"]').type('19.99')
    cy.get('input[name="inventory"]').type('7')

    cy.contains('button', 'Submit').click()

    cy.contains('Product Created')

    cy.contains('a', 'Back to Products').click()

    cy.contains('Test Product')
    cy.contains('19.99')
    cy.contains('7')
  })
})

