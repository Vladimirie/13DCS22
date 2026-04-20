<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class APIProductController extends Controller
{
    public function index()
    {
        $products = Product::with('categories');

        return response()->json([
            "data" => $products
        ]);
    }


    public function store(Request $request)
    {
        $validate = $request->validate([
            'category_id' => ['required', 'integer', 'exits:categories,id'],
            'description' => ['required', 'string', ''],
            'ad_date' => ['date'],
            'heavy' => ['required', 'integer', ''],
            'price' => ['required', 'integer', '']

        ]);

        $product = Product::create($validate);

        if ($product->fails()) {
            return response()->json([
                'message' => 'Hiányos adat!'
            ], 400);
        }

        return response()->json([
            'data' => $product
        ], 201);
    }
}


