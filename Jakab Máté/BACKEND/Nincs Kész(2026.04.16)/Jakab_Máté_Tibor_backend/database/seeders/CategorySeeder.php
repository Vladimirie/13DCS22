<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use App\Models\Category;

class CategorySeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $categories = [
            [
                Category::insert([
                    ["name"=> "Fotel"],
                    ["name"=> "Kanapé"],
                    ["name"=> "Asztal"],
                    ["name"=> "Komód"],
                    ["name"=> "Polc"],
                    ["name"=> "Tv_állvány"]
                ])

            ]
        ];
        class DatabaseSeeder extends Seeder
{
    public function run(): void
    {
        $this->call([
            CategorySeeder::class
        ]);
    }
}
    }
}
