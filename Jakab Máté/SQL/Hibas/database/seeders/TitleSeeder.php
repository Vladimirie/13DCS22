<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class TitleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        Title::insert([
            [
                'category_id' => 1,
                'title' => 'Az arany ember',
                'author' => 'Jókai Mór',
                'published_year' => 1872,
                'pages' => 300
            ],
            [
                'category_id' => 2,
                'title' => 'Dune',
                'author' => 'Frank Herbert',
                'published_year' => 1965,
                'pages' => 412
            ]
        ]);
    }
}
