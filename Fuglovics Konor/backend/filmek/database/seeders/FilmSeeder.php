<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class FilmSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $categories = DB::table('categories')->pluck('id', 'name');
        DB::table('films')->insert
        ([
            [
                'category_id' => $categories['Sci-Fi'],
                'title' => 'Star Trek',
                'year' => 1966,
                'director' => 'Gene Roddenberry'
            ],
            [
                'category_id' => $categories['Sci-Fi'],
                'title' => 'Star Wars',
                'year' => 1977,
                'director' => 'George Lucas'
            ],
            [
                'category_id' => $categories['Horror'],
                'title' => 'The Shining',
                'year' => 1980,
                'director' => 'Stanley Kubrick'
            ],
            [
                'category_id' => $categories['Comedy'],
                'title' => 'The Amazing Digital Circus',
                'year' => 2023,
                'director' => 'Gooseworx'
            ],
            [
                'category_id' => $categories['Action'],
                'title' => 'The Fast & The Furious',
                'year' => 2001,
                'director' => 'Rob Cohen, David Leitch, James Wan, Justin Lin'
            ],
            [
                'category_id' => $categories['Mystery'],
                'title' => 'Sherlock Holmes',
                'year' => 1939,
                'director' => 'Alfred L. Werker'
            ],
            [
                'category_id' => $categories['Romance'],
                'title' => 'Pearl Harbor',
                'year' => 2001,
                'director' => 'Michael Bay'
            ]
        ]);
    }
}
