<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class BookSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $categories=DB::table('categories')->pluck('id', 'name');
        DB::table('books')->insert
        ([
            [
                'category_id' => $categories['Dystopian'],
                'title' => 1984,
                'author' => "George Orwell",
                'published' => 1949,
                'pages' => 328
            ],
            [
                'category_id' => $categories['History'],
                'title' => 'Animal Farm',
                'author' => 'George Orwell',
                'published' => 1945,
                'pages' => 92
            ],
            [
                'category_id' => $categories['Horror'],
                'title' => "IT",
                'author' => 'Stephen King',
                'published' => 1986,
                'pages' => 1398
            ]
        ]);
    }
}
