<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class MenuItam extends Model
{
    protected $fillable = [
        'category_id',
        'name',
        'desc',
        'price',
        'is_avaliable'
    ];

    protected $casts = [
        'price' => 'decimal:2',
        'is_available' => 'boolean'
    ];

    public function category(): BelongsTo{
        return $this->belongsTo(Category::class);
    }
}
