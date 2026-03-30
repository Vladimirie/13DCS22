<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Book extends Model
{
    protected $fillable =
    [
        'title',
        'author',
        'published',
        'pages'
    ];
    public function categories():BelongsTo
    {
        return $this->BelongsTo(Category::class);
    }
}
