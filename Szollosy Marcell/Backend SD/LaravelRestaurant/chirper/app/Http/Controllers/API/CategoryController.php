<?php

namespace App\Http\Controllers\API;

use App\Models\Category;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;



class CategoryController extends Controller
{
    public function show(Request $request){
        $validated = $request->validate([
            'id' => ['required', 'integer', 'exists:categories,id']
        ]);

        $category = Category::findOrFail($validated['id']);

        return response()->json([
            'data' => $category
        ]);

    public function store(request $request){
            $validated = $request->validate([
                'name' => ['requered', 'string', 'max:255', 'unique:categories,name'],
                'is_active'=>['boolean']
            ]);
        }

        $category = Category::create($validated);

        return response()->json([
            'data' => $category
        ], 201);
    


        public function update(request $request){
            $validated = $request->([
                'id' => ['required', 'integer', 'exists:categories,id'],
                'name' => ['required', 'string', 'max:255'],
                'is_active' => ['boolean']
            ]);

            $category = Category::findOrFail($validated['id']);

            $category->update($validated);

            return response()->json([
                'data' => $category->fresh()
            ]);
        }
}}
