<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    use WithoutModelEvents;

    /**
     * Seed the application's database.
     */
    public function run(): void
    {
       
        DB::table("categories")->insert([
            ["name" => "Sport"],
            ["name" => "Terep"],
            ["name" => "Városi"],
            ["name" => "Luxus"],
            ["name" => "Elektromos"]
        ]);

        DB::table("cars")->insert([
            [
                'category_id' => 1,
                'name' => 'Ferrari',
                "description" => "egy új ferrari",
                "color" => "piros",
                "avaliable" => true,
                "price" => 2000000
            ]
        ]);

    }
}
