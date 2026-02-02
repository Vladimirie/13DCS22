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
        $categories = DB::table('categories')
        ->pluck('id','name');
        DB::table('menu_items')->insert([
            [
                'category_id' => $categories['Levesek'],
                'name' => 'Tyúkhús leves',
                'desc' => 'Tyúknyak, zöldségel',
                'price' => 1990
            ],
            [
                'category_id' => $categories['Levesek'],
                'name' => 'Gyulyásleves',
                'desc' => 'Marhahús, zöldségel, csipetke',
                'price' => 2190
            ],
            [
                'category_id' => $categories['Pizzák'],
                'name' => '4 Sajtos',
                'desc' => 'Paradicsom alap, cheddar sajt, mozzarella sajt, kék sajt, rukkola',
                'price' => 3590
            ],
            [
                'category_id' => $categories['Pizzák'],
                'name' => 'Hawaii',
                'desc' => 'Paradicsom alap, sajt, ananász, sonka',
                'price' => 3290
            ],
            [
                'category_id' => $categories['Desszertek'],
                'name' => 'Tiramisu',
                'desc' => 'Babapiskóta, kávé, kakaó, rumaroma',
                'price' => 3290
            ],
            [
                'category_id' => $categories['Italok'],
                'name' => 'Red Bull',
                'desc' => '300ml',
                'price' => 250
            ],
            [
                'category_id' => $categories['Italok'],
                'name' => 'Monster (fehér)',
                'desc' => '500ml',
                'price' => 650
            ],
            [
                'category_id' => $categories['Italok'],
                'name' => 'Kőbányai',
                'desc' => '2000ml',
                'price' => 500
            ]
        ]);
    }
}
