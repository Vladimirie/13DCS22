<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
class MenuItem extends Model
{
    protected $fillable = [
        'category_id',
        'name',
        'desc',
        'price',
        'is_available'
    ];

    protected $cast  = [
        'price' => 'decimal:2',
        'is_available' => 'boolean'
    ];

    public function category(): BelongsTo{
        return $this->belongsTo(Category::class);

    }
}
