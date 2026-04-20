<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ProductSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $categories=DB::table('categories')->pluck('id', 'name');
        DB::table('products')->insert
        ([
            [
                'category_id' => $categories['Fotel'],
                'description' => 'barna bőr fotel',
                'ad_date' => 2026-03-16,
                'heavy' => true,
                'price' => 97499
            ],
            [
                'category_id' => $categories['Fotel'],
                'description' => 'piros varott fotel',
                'ad_date' => 2026-04-10,
                'heavy' => false,
                'price' => 84999
            ],
            [
                'category_id' => $categories['Kanapé'],
                'description' => 'szürke szőrme kanapé',
                'ad_date' => 2026-04-13,
                'heavy' => true,
                'price' => 127999
            ],
            [
                'category_id' => $categories['Kanapé'],
                'description' => 'barna L-alakú kanapé',
                'ad_date' => 2026-02-29,
                'heavy' => true,
                'price' => 169999
            ]
        ]);
    }
}
