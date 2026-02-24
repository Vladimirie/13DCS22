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
        //
        $categores = DB::table('categories')->pluck('id', 'name');
        
        Db::table('menu_items')->insert([
            ['category_id' => $categores['Levesek'],
            'name' => 'Tyúkhús leves',
            'desc' => 'Tyúknyak, zölségek',
            'price' => 1990 ],
            ['category_id' => $categores['Levesek'],
            'name' => 'Gulyásleves',
            'desc' => 'Marhahús, zölségek, csipetke',
            'price' => 2030 ],
            ['category_id' => $categores['Pizzák'],
            'name' => '4 sajtos',
            'desc' => 'Paradicsom alap, cheddar sajt, Mozzerela, Rugfgd',
            'price' => 3200],
            ['category_id' => $categores['Pizzák'],
            'name' => 'Hawaii',
            'desc' => 'Paradicsom alap, cheddar sajt, Mozzerela, Rugfgd',
            'price' => 1990 ],
            ['category_id' => $categores['Desszertek'],
            'name' => 'Tiramiszu',
            'desc' => 'Babuiskóta,rum, ',
            'price' => 1990 ],
            ['category_id' => $categores['Italok'],
            'name' => 'Fehér monster',
            'desc' => '500ml ',
            'price' => 1990 ]
        ]);

    }
}