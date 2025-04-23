using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

public class Water : MonoBehaviour
{
    private SpriteShapeController sc;
    private Spline spline;
    private float scale;
    private Vector2 basePointPos;
    private int n;
    private float[] vec;
    [SerializeField] private float interval = 0.45f;
    [SerializeField] private float maxWave = 0.5f;
    [SerializeField] private float minWave = 0.05f;
    [SerializeField] private float k = 0.09f;
    [SerializeField] private float waterPow = 0.05f;
    [SerializeField] private float waveRate = 0.65f;
    [SerializeField] private float waveTime = 0.08f;

    private void Start()
    {
        sc = GetComponent<SpriteShapeController>();
        spline = sc.spline;
        basePointPos = spline.GetPosition(1);
        scale = transform.localScale.x;
        n = (int)(-basePointPos.x * scale * 2 / interval) + 1;
        vec = new float[n - 2];
        for (int i = 0; i < n - 2; i++) vec[i] = 0;
        Vector3 p = basePointPos;
        for (int i = 2; i < n; i++)
        {
            p += interval * Vector3.right / scale;
            spline.InsertPointAt(i, p);
            spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spline.SetLeftTangent(i, 0.1f * interval * Vector3.left / scale);
            spline.SetRightTangent(i, 0.1f * interval * Vector3.right / scale);
            spline.SetHeight(i, 0.1f);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            vec[i - 2] -= k * pos.y;
            vec[i - 2] *= 0.9f;
            pos += vec[i - 2] * Vector3.up;
            spline.SetPosition(i, pos);
        }
    }

    private async void WaveCreate(Collider2D collision)
    {
        int i = (int)((collision.transform.position.x - transform.position.x - basePointPos.x * scale) / interval) + 1;
        if (i < 2) i = 2;
        else if (i > n - 1) i = n - 1;
        float y_collisionVelocity = collision.GetComponent<Rigidbody2D>().velocity.y;
        Vector3 pos = spline.GetPosition(i);
        Vector3 dv = pos + waterPow * y_collisionVelocity * Vector3.up;
        if (dv.y > maxWave) dv = new(pos.x, maxWave, 0);
        else if (dv.y < -maxWave) dv = new(pos.x, -maxWave, 0);
        spline.SetPosition(i, dv);
        int l = i;
        int r = i;
        float y = dv.y;
        if (y * y != maxWave * maxWave) y *= waveRate * Random.Range(0.8f, 1.2f);
        while (true)
        {
            if (y * y < minWave * minWave) return;
            l--;
            if (l > 1)
            {
                pos = spline.GetPosition(l);
                spline.SetPosition(l, new(pos.x, y, 0));
            }
            r++;
            if (r < n)
            {
                pos = spline.GetPosition(r);
                spline.SetPosition(r, new(pos.x, y, 0));
            }
            if (l <= 1 && r >= n) return;
            await UniTask.Delay((int)(waveTime * 1000));
            y *= waveRate * Random.Range(0.8f, 1.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Rigidbody2D>()) return;
        WaveCreate(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.GetComponent<Rigidbody2D>()) return;
        WaveCreate(collision);
    }
}