<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Product;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    public function index()
    {
        $products = Product::with('category');
        return response()->json
        ([
            'data' => $products
        ]);
    }
    public function store(Request $request)
    {
        $validated = $request->validate
        ([
            'category_id' => ['required', 'integer', 'exists:categories,id'],
            'description' => ['required', 'string'],
            'ad_date' => ['date'],
            'heavy' => ['required', 'boolean'],
            'price' => ['required', 'integer']
        ]);
        $product = Product::create($validated);
        if($product->fails())
        {
            return response()->json
            ([
                'message' => 'No data :('
            ], 400);
        }
        return response()->json
        ([
            'data' => $product
        ], 201);
    }
}
