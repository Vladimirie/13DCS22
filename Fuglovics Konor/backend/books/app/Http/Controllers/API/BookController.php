<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Book;
use Illuminate\Http\Request;

class BookController extends Controller
{
    public function show(Request $request)
    {
        $validated = $request->validate
        ([
            'id' => ['required', 'integer', 'exists:categories,id'],
        ]);
        $category = Book::findOrFail($validated['id']);
        return response()->json
        ([
            'data' => $category
        ]);
    }
    public function update(Request $request)
    {
        $validated = $request->validate
        ([
            'id' => ['required', 'integer', 'exists:books,id'],
            'category_id' => ['integer', 'exists:categories,id'],
			'title' => ['string'],
            'author' => ['string'],
			'published' => ['numeric'],
            'pages' => ['numeric'],
        ]);
        $item = Book::findOrFail($validated['id']);
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
			'author' => ['required', 'string', 'max:255'],
            'published' => ['required', 'numeric'],
            'pages' => ['required', 'numeric']
 		]);
		$item = Book::create($validated)->load('category');
		return response()->json
		([
			'data' => $item
		],201);
	}
	public function destroy(Request $request)
	{
		$validated = $request->validate
		([
			'id' => ['required', 'integer', 'exists:books,id'],
		]);
		$item = Book::findOrFail($validated['id']);
		$item->destroy($validated);
		return response()->json
		([
			'message' => 'Deleted! :D'
		],204);
	}
}
