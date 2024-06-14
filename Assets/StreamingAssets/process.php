<?php session_start(); //THIS STARTS THE SESSION
// Allow CORS
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");

// Handle preflight requests
if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(204);
    exit;
}

// Handle POST requests
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['score'])) {
    $score = $_POST['score'];
    $_SESSION['playerScore'] = $score;

    // Sanitize the input to prevent code injection
    $score = htmlspecialchars($score);

    $file = 'scores.txt';
    $current = file_get_contents($file);
    $current .= "Score: " . $score . "\n";
    file_put_contents($file, $current);

    echo "Score saved successfully";
} else {
    echo "No score received";
}
?>

