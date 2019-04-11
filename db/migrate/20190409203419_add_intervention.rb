class AddIntervention < ActiveRecord::Migration[5.2]
  def change
    create_table :interventions do |t|
      t.references :author_id
      t.references :customer_id
      t.integer :building_id , foreign_key: {on_delete: :cascade, on_update: :cascade}
      t.integer :battery_id , foreign_key: {on_delete: :cascade, on_update: :cascade}
      t.integer :column_id , foreign_key: {on_delete: :cascade, on_update: :cascade}
      t.integer :elevator_id , foreign_key: {on_delete: :cascade, on_update: :cascade}
      t.integer :employee_id
      t.timestamp :startIntervention
      t.timestamp :endIntervention
      t.string :result
      t.string :report
      t.string :status

      # , foreign_key: {on_delete: :cascade, on_update: :cascade}
    end
  end
end
