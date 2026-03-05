<?php

namespace App\Http\Controllers\API;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Models\Film;

class FilmController extends Controller
{
    public function show(Request $request)
    {
        $validated = $request->validate
        ([
            'id' => ['required', 'integer', 'exists:categories,id'],
        ]);
        $category = Film::findOrFail($validated['id']);
        return response()->json
        ([
            'data' => $category
        ]);
    }
    public function update(Request $request)
    {
        $validated = $request->validate
        ([
            'id' => ['required', 'integer', 'exists:films,id'],
            'category_id' => ['integer', 'exists:categories,id'],
			'title' => ['string'],
			'year' => ['numeric'],
			'director' => ['string']
        ]);
        $item = Film::findOrFail($validated['id']);
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
			'title' => ['required', 'string', 'max:255'],
			'year' => ['required', 'numeric'],
			'director' => ['required', 'string', 'max:255']
 		]);
		$item = Film::create($validated)->load('category');
		return response()->json
		([
			'data' => $item
		],201);
	}
	public function destroy(Request $request)
	{
		$validated = $request->validate
		([
			'id' => ['required', 'integer', 'exists:films,id'],
		]);
		$item = Film::findOrFail($validated['id']);
		$item->destroy($validated);
		return response()->json
		([
			'message' => 'Deleted! :D'
		],204);
	}
}
