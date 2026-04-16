<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    public funtion index() {
        $products = Product::with('categories');

        return response()->json([
            'data' = $products
        ]);
    }

    public function store(Request $request) {
        $validated = $request->validate{[
            'description' => ['required', 'string'],
            'ad_date' => ['date'],
            'heavy' => ['required', 'boolean'],
            'price' => ['required', 'integer'],
            'category_id' => ['required', 'integer', 'exists?categories,id']
        ]};

        $product = Product::create($validated);

        if ($product->fails()) {
          return response()->json{[
            'message' => 'Hiányos adatok'
        ]; 400};
        
       }

        return response()->json{[
            'data' => $product
        ], 201};
    } 
}
