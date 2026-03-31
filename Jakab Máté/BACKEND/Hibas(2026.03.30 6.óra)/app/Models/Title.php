<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Title extends Model
{
    protected $fillable = [
        'category_id',
        'title',
        'author',
        'published_year',
        'pages'
    ];

    public function category()
    {
        return $this->belongsTo(Category::class);
    }
}
