<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\MenuItem;
use Illuminate\Http\Request;

class MenuItemController extends Controller
{
	public function show(Request $request)
	{
		$validated = $request->validate
		([
			'id' => ['required', 'integer', 'exists:menu_items,id'],
			'category_id' => ['integer', 'exists:categories,id'],
			'name' => ['string'],
			'price' => ['numeric'],
			'isavailable' => ['boolean']
		]);
		$item = MenuItem::findOrFail($validated['id']);
		$item->update($validated);
		return response()->json
		([
			'data' => $item->fresh()->load('category')
		]);
	}
	public function update(Request $request)
    {
        $validated = $request->validate
        ([
            'id' => ['required', 'integer', 'exists:menu_items,id'],
            'category_id' => ['integer', 'exists:categories,id'],
			'name' => ['string'],
			'price' => ['numeric'],
			'isavailable' => ['boolean']
        ]);
        $item = MenuItem::findOrFail($validated['id']);
        $item->update($validated);
        return response()->json
        ([
            'data' => $item->fresh()
        ]);
    }
	public function store(Request $request)
	{
		$validated = $request->validate
		([
			'category_id' => ['required', 'integer', 'exists:categories,id'],
			'name' => ['required', 'string', 'max:255'],
			'description' => ['nullable', 'string'],
			'price' => ['required', 'numeric', 'min:0'],
			'isavailable' => ['required', 'boolean']
		]);
		$item = MenuItem::create($validated)->load('category');
		return response()->json
		([
			'data' => $item
		],201);
	}
	public function destroy(Request $request)
	{
		$validated = $request->validate
		([
			'id' => ['required', 'integer', 'exists:menu_items,id'],
		]);
		$item = MenuItem::findOrFail($validated['id']);
		$item->destroy($validated);
		return response()->json
		([
			'message' => 'Deleted! :D'
		],204);
	}
}
