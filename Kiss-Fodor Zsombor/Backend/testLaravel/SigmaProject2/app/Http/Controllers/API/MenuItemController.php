<?php

namespace App\Http\Controllers\API;

namespace App\Http\Controllers\API;
use App\Models\Test;
use App\Http\Controllers\Controller;
use App\Models\MenuItem;
use Illuminate\Http\Request;


class MenuItemController extends Controller
{
    public function update(Request $request) {
        $validated = $request->validate(([
            'id' => ['required', 'integer', 'exists:menu_items,id'],
            'category_id' => ['integer', 'exists:categories_id'],
            'name' => ['string'],
            'price' => ['numeric'],
            'is_available' => ['boolean']
        ]));

        $item = MenuItem::findOrFail($validated['id']);

        $item->update($validated);

        return response()->json([
            'date' => $item->fresh()->load('category')
        ]);
    }

    public function store(Request $request) {
        $validated = $request->validate([
            'name' => ['required', 'max:255', 'string'],
            'price' => ['required', 'numeric'],
            'is_available' => ['boolean']
        ]);
        $item = MenuItem::create($validated);
        return response()->json([
            'data' => $item
        ], 201);
    }

    public function destroy(Request $request){
        $validated = $request->validate([
            'id' => ['required', 'integer', 'exists:menu_items,id'],
        ]);

        $item = MenuItem::findOrFail($validated['id']);

        $item->delete();

        return response()->json([
            'messege' => 'Deleted'
        ], 204);
       }
}