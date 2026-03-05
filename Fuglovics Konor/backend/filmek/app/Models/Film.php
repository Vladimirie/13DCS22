<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Film extends Model
{
    protected $fillable =
    [
        'title',
        'year',
        'director'
    ];
    public function categories():BelongsTo
    {
        return $this->BelongsTo(Category::class);
    }
}
