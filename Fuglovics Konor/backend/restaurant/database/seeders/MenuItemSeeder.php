<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class MenuItemSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $categories=DB::table('categories')->pluck('id', 'name');
        DB::table('menu_items')->insert
        ([
            [
                'category_id' => $categories['Soups'],
                'name' => 'Chicken soup',
                'description' => 'Chicken neck, vegetables',
                'price' => 1990
            ],
            [
                'category_id' => $categories['Pizzas'],
                'name' => 'Quattro Formaggi',
                'description' => 'Tomato base, cheddar cheese, mozzarella, ruccola',
                'price' => 3590
            ],
            [
                'category_id' => $categories['Pizzas'],
                'name' => 'Hawaiian',
                'description' => 'Tomato base, cheese, pineapple, ham',
                'price' => 3290
            ],
            [
                'category_id' => $categories['Desserts'],
                'name' => 'Tiramisu',
                'description' => 'Biscuits, cocoa powder, mascarpone',
                'price' => 1200
            ],
            [
                'category_id' => $categories['Drinks'],
                'name' => 'Coca-Cola',
                'description' => '330ml',
                'price' => 220
            ],
            [
                'category_id' => $categories['Drinks'],
                'name' => 'Coca-Cola Zero',
                'description' => '330ml',
                'price' => 220
            ],
            [
                'category_id' => $categories['Drinks'],
                'name' => 'Red Bull',
                'description' => '250ml',
                'price' => 300
            ],
            [
                'category_id' => $categories['Drinks'],
                'name' => 'Water',
                'description' => '250ml',
                'price' => 120,
            ],
            [
                'category_id' => $categories['Main course'],
                'name' => 'Fish & chips',
                'description' => 'Seasoned cooked cod, french fries',
                'price' => 3730
            ],
            [
                'category_id' => $categories['Main course'],
                'name' => 'Brassó style porkchop with french fries',
                'description' => 'Porkchop, french fries',
                'price' => 2990
            ],
            [
                'category_id' => $categories['Soups'],
                'name' => 'Onion cream soup',
                'description' => 'onion, vegetables',
                'price' => 2000
            ],
        ]);
    }
}
